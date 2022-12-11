import { useEffect } from "react";
import { useParams } from "react-router-dom";
import useFetch from "../../hooks/useFetch/useFetch";

import s from "./userPage.module.css";
function UserPage() {
  const { username, displayName, personalWebsite, profilePicUrl } = useParams();
  //useFetch(["user", `${username}`]);
  return (
    <div className={s.container}>
      <div
        className={s.profilePic}
        style={{ background: `url(${profilePicUrl})` }}
      ></div>
      <div className={s.userPg}>
        <div className={s.desc}>
          <h1>{`User ${username}`}</h1>
          <span>{`displayName ${displayName}`}</span>
          <span>{`website ${personalWebsite}`}</span>
        </div>
      </div>
    </div>
  );
}
export default UserPage;
