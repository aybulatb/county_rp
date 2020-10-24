import React, { useState, useEffect } from 'react';
import { useHistory, NavLink, useParams } from 'react-router-dom';
import styled from 'styled-components';
import BlueButton from 'AdminPanel/components/atoms/BlueButton';
import Input from 'AdminPanel/components/atoms/Input';
import EditPage from 'AdminPanel/components/templates/Edit';
import Checkbox from 'AdminPanel/components/molecules/Checkbox';
import { getPerson } from 'AdminPanel/services';
import { editPerson } from 'AdminPanel/services';
import { getGroupsFilterBy } from 'AdminPanel/services';
import { routes } from 'AdminPanel/routes';
import { Person } from 'AdminPanel/types';
import { Group } from 'AdminPanel/types';
import { Faction } from 'AdminPanel/types';
import { AdminLevel } from 'AdminPanel/types';
import { getFactionFilterBy } from 'AdminPanel/services';
import { getAdminLevelFilterBy } from 'AdminPanel/services';
import { handlerFactory, handlerFetchError } from 'AdminPanel/utils/handlerFactory';


const BlueButtonWithMargin = styled(BlueButton)`
  margin-left: 10px;
`;

export default () => {
  const { id } = useParams<{ id: string }>();

  const [person, setPerson] = useState<Person>({
    id: NaN,
    name: '',
    playerId: NaN,
    adminLevelId: '',
    factionId: '',
    groupId: '',
    leader: false,
    rank: NaN
  });
  const [personName, setPersonName] = useState('');
  const [isLeader, setIsLeader] = useState(false)
  const [groups, setGroups] = useState([] as Group[]);
  const [groupId, setGroupId] = useState('');
  const [factions, setFactions] = useState([] as Faction[]);
  const [factionId, setFactionId] = useState('');
  const [adminLevels, setAdminLevels] = useState([] as AdminLevel[]);
  const [adminLevelId, setAdminLevelId] = useState('');

  const history = useHistory();
  const prevLocation = routes.person;

  const onChangeIdFactory = (setId: React.Dispatch<React.SetStateAction<string>>) => {
    return (event: React.ChangeEvent<HTMLSelectElement>) => {
      setId(event.target.value);
    }
  }

  const onGroupIdChange = onChangeIdFactory(setGroupId);
  const onFactionIdChange = onChangeIdFactory(setFactionId);
  const onAdminLevelIdChange = onChangeIdFactory(setAdminLevelId);

  const handleEdit = handlerFactory(
    () => editPerson({
      ...person,
      groupId,
      name: personName,
      factionId,
      adminLevelId
    }), 
    () => history.push(prevLocation)
  );

  useEffect(() => {
    (async () => {
      try {
        const person = await getPerson(id);
        const factionsSearchResult = await getFactionFilterBy();
        const levelsSearchResult = await getAdminLevelFilterBy();
        const groupsSearchResult = await getGroupsFilterBy();

        const group = groupsSearchResult.items.find(item => item.id === person.groupId);
        const faction = factionsSearchResult.items.find(item => item.id === person.factionId);
        const adminLevel = levelsSearchResult.items.find(item => item.id === person.adminLevelId);

        setPerson(person);
        setPersonName(person.name);
        setGroups(groupsSearchResult.items);
        setGroupId(group?.id || '-');
        setIsLeader(person.leader);
        setFactions(factionsSearchResult.items);
        setFactionId(faction?.id || '-');
        setAdminLevels(levelsSearchResult.items);
        setAdminLevelId(adminLevel?.id || '-');
      } catch (error) {
        console.log(error);
        handlerFetchError(error);
      }
    })();
  }, [id]);

  return (
    <EditPage
      pageName='Редактировать'
      inputRows={[
        {
          name: 'Имя',
          innerElement: <Input value={personName} setValue={setPersonName} />
        },
        {
          name: 'Группа',
          innerElement: <select value={groupId} onChange={onGroupIdChange} onBlur={onGroupIdChange}>
            <option value={"-"}>-</option>
            {
              groups.map((group, key) => (
                <option key={key} value={group.id}>
                  {`${group.id} : ${group.name}`}
                </option>
              ))
            }
          </select>
        },
        {
          name: 'Фракция',
          innerElement: <select value={factionId} onChange={onFactionIdChange} onBlur={onFactionIdChange}>
            <option value={"-"}>-</option>
            {
              factions.map((faction, key) => (
                <option key={key} value={faction.id}>
                  {`${faction.id} : ${faction.name}`}
                </option>
              ))
            }
          </select>
        },
        {
          name: 'Админ уровень',
          innerElement: <select value={adminLevelId} onChange={onAdminLevelIdChange} onBlur={onAdminLevelIdChange}>
            <option value={"-"}>-</option>
            {
              adminLevels.map((level, key) => (
                <option key={key} value={level.id}>
                  {`${level.id} : ${level.name}`}
                </option>
              ))
            }
          </select>
        },
        {
          name: 'Лидер',
          innerElement: <Checkbox checked={isLeader} id='rights' handleCheck={() => setIsLeader(!isLeader)} />
        },
      ]}
      buttons={
        <>
          <BlueButton as={NavLink} to={prevLocation}>
            Отмена
          </BlueButton>

          <BlueButtonWithMargin onClick={handleEdit}>
            Сохранить
          </BlueButtonWithMargin>
        </>
      }
    />
  )
}