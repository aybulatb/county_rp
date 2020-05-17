import React, { useEffect } from "react";
import { useParams } from 'react-router-dom';
import { observer, inject } from 'mobx-react';
import Base from 'components/templates/Base';
import { ProfileStore } from 'stores/ProfileStore';


type ProfileProps = {
  profileStore?: ProfileStore
}

const Profile = ({ profileStore }: ProfileProps) => {
  const { login } = useParams();


  useEffect(() => {
    profileStore?.getProfile(login);
  }, [profileStore, login]);

  if (profileStore?.persons.length === 0) {
    return <Base>Загрузка</Base>
  } else {
    console.log()
    return (
      <Base>
        <div>
          {(profileStore?.isLoading) ?
            <div>Загрузка</div>
            :
            <div>
              <div>Логин: {profileStore?.player.login} ({profileStore?.player.id})</div>
              <div>Персонажи:</div>
              <hr />
              {profileStore?.persons.map(p =>
                <div>
                  <div>Имя: {p.person.name} ({p.person.id})</div>
                  <div>Фракция: {(p.person.factionId === null) ? 'Нет' : p.faction.name + ' (' + p.faction.id + ')'}</div>
                  <div>Имущество:</div>
                  {p.vehicles.map(v =>
                    <div>
                      <div>{v.id}</div>
                    </div>
                  )}
                  <br />
                </div>
              )}
            </div>
          }
        </div>
      </Base>
    );
  }
}

export default inject('profileStore')(observer(Profile));