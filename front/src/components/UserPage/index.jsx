import { useEffect } from "react";
import { useParams } from "react-router-dom";
import useFetch from "../../hooks/useFetch/useFetch";

import s from "./userPage.module.css";
function UserPage() {
  const { username, displayName } = useParams();
  useFetch(["user", username]);
  return (
    <div className={s.userPg}>
      {username}
      {displayName}
    </div>
  );
}
export default UserPage;
