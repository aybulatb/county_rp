import React, { useEffect } from "react";
import { useParams } from 'react-router-dom';
import { observer, inject } from 'mobx-react';
import Base from 'components/templates/Base';
import { ProfileStore } from 'store/ProfileStore';


type ProfileProps = {
  profileStore?: ProfileStore
}

const Profile = (props: ProfileProps) => {
  const { login } = useParams();

  const fetchProfile = props.profileStore?.getProfile;

  useEffect(() => {
    fetchProfile && fetchProfile(login);
  }, [fetchProfile, login]);

  return (
    <Base>
      <div>
        {(props.profileStore?.isLoading) ?
          <div>Загрузка</div>
          :
          <div>
            <div>Логин: {props.profileStore?.player.login} ({props.profileStore?.player.id})</div>
            <div>Персонажи:</div>
            {props.profileStore?.persons.map(p =>
              <div>
                <div>Имя: {p.person.name} ({p.person.id})</div>
                <div>Фракция: {(p.person.fractionId === null) ? 'Нет' : p.fraction.name + ' (' + p.fraction.id + ')'}</div>
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

export default inject('profileStore')(observer(Profile));