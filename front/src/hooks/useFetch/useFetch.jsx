import axios from "axios";
import { useSelector } from "react-redux";

function useFetch() {
  const givenLink = useSelector((state) => state.givenLink.givenLink);
  let name = givenLink.slice(19).slice(0, givenLink.match(/\//).index);
  let ind = 19 + givenLink.slice(19).match(/\//).index;
  // rep done wrong
  let rep = givenLink.slice(ind).slice(0, givenLink.match(/\//).index);
  axios
    .get("/api/v1/github/repository/", {
      params: {
        owner: `${a}`,
        name: `${a}`,
      },
    })
    .catch((error) => {
      console.log("error " + error);
      console.log(error.request);
    })
    .then((response) => {});
}

export default useFetch;
