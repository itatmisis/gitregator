import { useSelector } from "react-redux";
import axios from "axios";

import s from "./subHead.module.css";

function SubHeader() {
  const rep = useSelector((state) => state.rep.rep);
  const API_URL = "https://91.77.161.247:7259/api/v1/github/repository/excel/";

  const doDownloadExcel = async (name = "report") => {
    const owner = rep["repositoryOwner"];
    const repName = rep["repositoryName"];
    const link = `${owner}/${repName}`;
    const url = API_URL + link;
    const response = await axios.get(url, {
      headers: "header",
      responseType: "blob",
    });
    ///// link from back
    const blob = new Blob([response.data], {
      type: "application/vnd.ms-excel",
    });
    const linkPDF = document.createElement("a");
    linkPDF.href = window.URL.createObjectURL(blob);
    linkPDF.download = name + ".xlsx";
    linkPDF.click();
  };
  return (
    <div className={s.subHeader}>
      <div className={s.desc}>
        <h1>{rep[0]["repositoryName"]}</h1>
        <span>{rep[0]["repositoryDescription"]}</span>
      </div>
      <div className={s.desc}>
        <h1> {`folowers: ${rep[0]["collaborators"][0]["followersCount"]}`}</h1>
        <span>{`following: ${rep[0]["collaborators"][0]["followingCount"]}`}</span>
      </div>

      <button className={s.exportBtn} onClick={doDownloadExcel}></button>
    </div>
  );
}

export default SubHeader;
