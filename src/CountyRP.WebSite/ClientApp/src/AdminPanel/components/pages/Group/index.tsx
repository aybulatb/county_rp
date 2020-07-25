import React, {useState} from 'react';
import { NavLink } from 'react-router-dom';
import BlueButton from 'AdminPanel/components/atoms/BlueButton';
import Input from 'AdminPanel/components/atoms/Input';
import CategoryPage from 'AdminPanel/components/templates/CategoryPage/new';
import { routes } from 'AdminPanel/routes';
import { useStore } from 'AdminPanel/stores';
import { observer } from 'mobx-react';


const GroupPage = observer(() => {
  const [groupId, setGroupId] = useState('');
  const [groupName, setGroupName] = useState('');
  const { groupsSearchStore } = useStore();

  return (
    <CategoryPage
      topButtons={
        <BlueButton as={NavLink} to='/admin/group/create' >
          Создать
        </BlueButton>
      }
      inputRows={[
        {
          name: 'ID',
          innerComponent: <Input value={groupId} setValue={setGroupId} />
        },
        {
          name: 'Имя группы',
          innerComponent: <Input value={groupName} setValue={setGroupName} />
        }
      ]}
      searchTableProps={{
        headers: ['ID', 'Название'],
        searchResultsItems: groupsSearchStore.searchResult.map(group => [group.id, group.name]),
        editRoute: routes.editGroup,
        maxPage: groupsSearchStore.maxPage,
        currentPage: groupsSearchStore.currentPage,
        goToNextPage: groupsSearchStore.goToNextPage,
        goToPrevPage: groupsSearchStore.goToPrevPage,
        search: () => {groupsSearchStore.searchGroups(groupId, groupName)}
      }}
    />
  );
})


export default GroupPage;