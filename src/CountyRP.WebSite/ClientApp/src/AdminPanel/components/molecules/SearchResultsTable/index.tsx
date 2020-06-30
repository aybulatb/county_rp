import React from 'react';
import { NavLink } from 'react-router-dom';
import TableWrapper from 'AdminPanel/components/molecules/SearchResultsTable/_TableWrapper';
import TableRow from 'AdminPanel/components/molecules/SearchResultsTable/_TableRow';
import TableHeader from 'AdminPanel/components/molecules/SearchResultsTable/_TableHeader';
import BlueButton from 'AdminPanel/components/atoms/BlueButton';


type ResultsTableProps = {
  headers: string[]
  searchResultsItems: string[][]
  editRoute: string
}

export default ({ headers, searchResultsItems, editRoute }: ResultsTableProps) => (
  <TableWrapper>
    <table>
      <thead>
        <TableRow>
          {
            headers.map((header, key) => (
              <TableHeader key={key} width="120px">
                {header}
              </TableHeader>
            ))
          }
          <TableHeader></TableHeader>
        </TableRow>
      </thead>
      <tbody>
        {
          searchResultsItems.map((item, key) => (
            <TableRow key={key}>
              {
                item.map((itemProp, key) => <td key={key}>{itemProp}</td>)
              }

              <td style={{ textAlign: 'right' }}>
                <BlueButton as={NavLink} to={`${editRoute}/${item[0]}`}>
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