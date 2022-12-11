import axios from "axios";
import { useSelector, useDispatch } from "react-redux";
import { setRep } from "../../slices/repSlice";
import { setUserInfo } from "../../slices/userInfoSlice";

function useFetch(props) {
  const dispatch = useDispatch();
  console.log("props ", props[0]);
  if (props[0] == "user") {
    axios
      .get(`/api/v1/github/member/${props[1].username}`, {
        params: {},
      })
      .catch((error) => {
        console.log("error " + error);
        console.log(error.request);
      })
      .then((response) => {
        console.log(response);
        dispatch(setUserInfo(response));
      });
  }
  if (props[0] == "rep") {
    axios
      .get(
        `/api/v1/github/repository/${props[1].repositoryOwner}/${props[1].repositoryName}`,
        {
          params: {},
        }
      )
      .catch((error) => {
        console.log("error " + error);
        console.log(error.request);
      })
      .then((response) => {
        console.log(response);
        dispatch(setRep(response));
      });
  }
}

export default useFetch;
