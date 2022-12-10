import { useEffect } from "react";

import axios from "axios";


const useFetch = () => {
  useEffect(() => {
    axios
      .get("/places/radius", {
        params: {
          lat: 37.62268066406251,
          long: 55.75068339731634,
          r: 1500,
        },
      })
      .catch((error) => {
        console.log("error " + error);
        console.log(error.request);
      })
      .then((response) => response && console.log(response));
    console.log(111);

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
  return <></>;
};
export default useFetch;
