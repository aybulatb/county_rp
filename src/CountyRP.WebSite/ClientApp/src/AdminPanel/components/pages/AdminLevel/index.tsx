import React, {useState} from 'react';
import { NavLink } from 'react-router-dom';
import BlueButton from 'AdminPanel/components/atoms/BlueButton';
import Input from 'AdminPanel/components/atoms/Input';
import CategoryPage from 'AdminPanel/components/templates/CategoryPage';
import { getAdminLevelFilterBy } from 'AdminPanel/services';
import { routes } from 'AdminPanel/routes';
import { AdminLevel } from 'AdminPanel/types';
import { handlerFetchError } from 'AdminPanel/utils/handlerFactory';


const AdminLevelPage = () => {
  const [adminLevelId, setAdminLevelId] = useState('');
  const [adminLevelName, setAdminLevelName] = useState('');
  const [adminLevels, setAdminLevels] = useState<AdminLevel[]>([]);
  const [pageNumber, setPageNumber] = useState(1);
  const [maxPage, setMaxPage] = useState(1);

  const handleSearch = async (numberOfPage: number) => {
    try {
      const response = await getAdminLevelFilterBy(numberOfPage, adminLevelId, adminLevelName);

      setAdminLevels(response.items);
      setMaxPage(response.maxPage);
      setPageNumber(response.page);
    } catch (error) {
      handlerFetchError(error);
    }
  }

  return(
    <CategoryPage
      topButtons={
        <BlueButton as={NavLink} to={routes.createAdminLevel}>Создать</BlueButton>
      }
      inputRows={[
        {
          name: 'ID',
          innerComponent: <Input value={adminLevelId} setValue={setAdminLevelId} />
        },
        {
          name: 'Имя',
          innerComponent: <Input value={adminLevelName} setValue={setAdminLevelName} />
        }
      ]}
      handleSearch={handleSearch}
      searchTableProps={{
        headers: ['ID', 'Имя','Бан'],
        searchResultsItems: adminLevels.map((level) => (
          [level.id, level.name, level.ban.toString()]
        )),
        editRoute: routes.editAdminLevel,
        maxPage,
        pageNumber
      }}
    />
  )
}


export default AdminLevelPage;