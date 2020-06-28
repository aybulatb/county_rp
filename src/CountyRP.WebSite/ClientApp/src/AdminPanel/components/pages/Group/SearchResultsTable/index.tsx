import React from 'react';
import { NavLink } from 'react-router-dom';
import TableWrapper from './_TableWrapper';
import TableRow from './_TableRow';
import TableHeader from './_TableHeader';
import BlueButton from 'AdminPanel/components/atoms/BlueButton';


type ResultsTableProps = {
  searchResultsItems: {
    id: string
    name: string
  }[]
}

export default ({ searchResultsItems }: ResultsTableProps) => (
  <TableWrapper>
    <table>
      <thead>
        <TableRow>
          <TableHeader width="100px">ID</TableHeader>
          <TableHeader>Название</TableHeader>
          <TableHeader></TableHeader>
        </TableRow>
      </thead>
      <tbody>
        {
          searchResultsItems.map((item, key) => (
            <TableRow key={key}>
              <td>{item.id}</td>
              <td>{item.name}</td>
              <td style={{ textAlign: 'right' }}>
                <BlueButton as={NavLink} to={`/admin/group/edit/${item.id}`}>
                  Редактировать
                </BlueButton>
              </td>
            </TableRow>
          ))
        }
      </tbody>
    </table>
  </TableWrapper>
)