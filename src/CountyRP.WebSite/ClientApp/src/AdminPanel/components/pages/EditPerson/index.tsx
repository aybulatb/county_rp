import React, { useState, useEffect } from 'react';
import { useHistory, NavLink, useParams } from 'react-router-dom';
import styled from 'styled-components';

import BlueButton from 'AdminPanel/components/atoms/BlueButton';
import Input from 'AdminPanel/components/atoms/Input';
import EditPage from 'AdminPanel/components/templates/Edit';
import Checkbox from 'AdminPanel/components/molecules/Checkbox';

import { getPerson } from 'AdminPanel/services/person/getPerson';
import { editPerson } from 'AdminPanel/services/person/editPerson';
import { getGroupsFilterBy } from 'AdminPanel/services/group/getGroupsFilterBy';

import { routes } from 'AdminPanel/routes';

import { Person } from 'AdminPanel/services/person/Person';
import { Group } from 'AdminPanel/services/group/Group';
import { Faction } from 'AdminPanel/services/faction/Faction';
import { AdminLevel } from 'AdminPanel/services/adminLevel/AdminLevel';
import { getFactionFilterBy } from 'AdminPanel/services/faction/getFactionFilterBy';
import { getAdminLevelFilterBy } from 'AdminPanel/services/adminLevel/getAdminLevelFilterBy';


const BlueButtonWithMargin = styled(BlueButton)`
  margin-left: 10px;
`;


export default () => {
  const { id } = useParams<{ id: string }>();

  const [person, setPerson] = useState<Person>();
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

  const editHandler = async () => {
    try {
      if (person) {
        const fetchResult = await editPerson({
          ...person,
          groupId,
          name: personName,
          factionId,
          adminLevelId
        });
        
        if (fetchResult === 0) {
          history.push(prevLocation)
        }
      }
    } catch (error) {
      console.dir(error);
    }
  }

  const fetchGroups = async () => {
    try {
      const fetchResult = await getGroupsFilterBy();

      if (fetchResult.items.length !== 0) {
        setGroups(fetchResult.items);
        setGroupId(fetchResult.items[0].id);
      }
    } catch (error) {
      console.dir(error);
    }
  }

  useEffect(() => {
    fetchGroups();

    (async () => {
      try {
        const person = await getPerson(id);
        const factionsSearchResult = await getFactionFilterBy();
        const levelsSearchResult = await getAdminLevelFilterBy();

        setPerson(person);
        setPersonName(person.name);
        setGroupId(person.groupId);
        setIsLeader(person.leader);
        setFactions(factionsSearchResult.items);
        setFactionId(person.factionId || '');
        setAdminLevels(levelsSearchResult.items);
        setAdminLevelId(person.adminLevelId || '');
      } catch (error) {
        console.log(error);
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
          innerElement: <select onBlur={(event) => {setGroupId(event.target.value)}}>
            {
              groups.map((group, key) => <option key={key} value={group.id}>{group.name}</option>)
            }
          </select>
        },
        {
          name: 'Фракция',
          innerElement: <select onBlur={(event) => {setFactionId(event.target.value)}}>
            {
              factions.map((faction, key) => <option key={key} value={faction.id}>{faction.name}</option>)
            }
          </select>
        },
        {
          name: 'Админ уровень',
          innerElement: <select onBlur={(event) => {setAdminLevelId(event.target.value)}}>
            {
              adminLevels.map((level, key) => <option key={key} value={level.id}>{level.name}</option>)
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

          <BlueButtonWithMargin onClick={editHandler}>
            Сохранить
          </BlueButtonWithMargin>
        </>
      }
    />
  )
}