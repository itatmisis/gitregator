import axios from "axios";
import { useSelector, useDispatch } from "react-redux";

import { setRep } from "../../slices/repSlice";
import { setUserInfo } from "../../slices/userInfoSlice";
import { setMvpList } from "../../slices/mvpListSlice";
function useFetch(props) {
  const dispatch = useDispatch();
  const mvpList = useSelector((state) => state.mvpList.mvpList);
  const rep = useSelector((state) => state.rep.rep);
  console.log("fetch", props);

  if (props[0] == "user") {
    axios
      .get(
        `https://91.77.161.247:7259/api/v1/github/member/${props[1].username}`,
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
        dispatch(setUserInfo(response));
      });
  }
  if (props[0] == "rep") {
    axios
      .get(
        `https://91.77.161.247:7259/api/v1/github/repository/${props[1][0]}/${props[2]}`,
        {
          params: {},
        }
      )
      .catch((error) => {
        console.log("error " + error);
        console.log(error.request);
      })
      .then((response) => {
        console.log("data", response["data"]);
        dispatch(() => setRep(response["data"]));
        dispatch(() => setMvpList(rep["collaborators"]));
        console.log("rep ", rep[0]["collaborators"]);
        console.log("mvp", mvpList);
      });
  }
}

export default useFetch;
