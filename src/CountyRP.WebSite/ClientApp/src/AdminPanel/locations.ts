import { routes } from 'AdminPanel/routes';

type Location = {
  description: string
  name: string
  route: string
}

export const locations: Location[] = [
  {
    name: 'Игроки',
    description: 'Описание',
    route: routes.players
  },
  {
    name: 'Группы',
    description: 'Описание',
    route: routes.group
  },
  {
    name: 'Персонажи',
    description: 'Описание',
    route: routes.person
  },
  {
    name: 'Фракции',
    description: 'Описание',
    route: routes.faction
  },
  {
    name: 'Админ уровни',
    description: 'Описание',
    route: routes.adminLevel
  },
]