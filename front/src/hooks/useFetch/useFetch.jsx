import axios from "axios";
import { useSelector } from "react-redux";

function useFetch(props) {
  const givenLink = useSelector((state) => state.givenLink.givenLink);

  /*
  let name = givenLink.slice(20).slice(0, givenLink.match(/\//).index - 1);
  let ind = 19 + givenLink.slice(20).match(/\//).index + 2;
  //console.log(givenLink.slice(20));
  console.log(
    givenLink.slice(
      givenLink.match(/\/.*\//),
      givenLink
        .slice(givenLink.match(/\/.*\//), givenLink.length - 1)
        .match(/\//)
    )
  );
  // rep done wrong
  let rep = givenLink.slice(ind).slice(0, givenLink.match(/\//).index - 1);
  console.log(rep, name);*/
  /*
  let givenLink =
    " https://github.com/Wokkta/SberCase/blob/master/src/components/Reg_pg_1.js";
  console.log(givenLink.slice(/\/\w*\//));*/
  console.log("props ", props[0]);
  if (props[0] == "user") {
    axios
      .get("/api/v1/github/member/", {
        params: {
          username: `${props[1].username}`,
        },
      })
      .catch((error) => {
        console.log("error " + error);
        console.log(error.request);
      })
      .then((response) => {
        console.log(response);
      });
  }
  if (props[0] == "rep") {
    axios
      .get("/api/v1/github/repository/", {
        params: {
          owner: `${props[1].repositoryOwner}`,
          name: `${props[1].repositoryName}`,
        },
      })
      .catch((error) => {
        console.log("error " + error);
        console.log(error.request);
      })
      .then((response) => {
        console.log(response);
      });
  }
}

export default useFetch;
