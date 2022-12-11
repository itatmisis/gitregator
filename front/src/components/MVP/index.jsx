import { useEffect, useMemo, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Link } from "react-router-dom";
import useFetch from "../../hooks/useFetch/useFetch";
import { setMvpList } from "../../slices/mvpListSlice";
import SubHeader from "../SubHeader";

import s from "./MVP.module.css";

function MVP() {
  const mvpList = useSelector((state) => state.mvpList.mvpList);
  const givenLink = useSelector((state) => state.givenLink.givenLink);
  const rep = useSelector((state) => state.rep.rep);
  const dispatch = useDispatch();
  const [list, setList] = useState(JSON.parse(JSON.stringify(mvpList)));
  useEffect(() => {
    setList(JSON.parse(JSON.stringify(mvpList)));
  }, []);

  useFetch([
    "rep",
    givenLink.match("(?<=github.com/)(.*?)(?=/)"),
    givenLink.match("(?<=github.com/.*?/)(.*?)(?=/)")[0], // name
  ]);
  /* useFetch([
      "user",
      givenLink.match("(?<=github.com/.*?/)(.*?)(?=/)")[0], // name
    ]);*/
  const fields = [
    "username",
    "commitsTotal",
    "issuesTotal",
    "pullRequestTotal",
    "mostUsedLanguage",
    "pullRequestTotal",
    "displayName",
  ];
  const [previousClick, setPreviousClick] = useState(false);
  function sortByParam(users, param, prevClick) {
    const same = prevClick === param;
    switch (typeof users[0][param]) {
      case "string":
        if (same) {
          users.sort((b, a) => {
            let fa = a[param].toLowerCase(),
              fb = b[param].toLowerCase();

            if (fa < fb) {
              return -1;
            }
            if (fa > fb) {
              return 1;
            }
            return 0;
          });
          setPreviousClick(false);
        } else {
          users.sort((a, b) => {
            let fa = a[param].toLowerCase(),
              fb = b[param].toLowerCase();

            if (fa < fb) {
              return -1;
            }
            if (fa > fb) {
              return 1;
            }
            return 0;
          });
          setPreviousClick(param);
        } /*
      users.forEach((e) => {
        console.log(`${e.username} ${e.commitsTotal} ${e.issuesTotal}`);
      });*/

        break;
      case "number":
        if (same) {
          users.sort((b, a) => {
            return b[param] - a[param];
          });
          setPreviousClick("");
        } else {
          users.sort((a, b) => {
            return b[param] - a[param];
          });
          setPreviousClick(param);
        }
        /*
      users.forEach((e) => {
        console.log(`${e.username} ${e.commitsTotal} ${e.issuesTotal}`);
      });*/

        break;
      default:
        console.log("wrong data");
        break;
    }

    let answer = JSON.parse(JSON.stringify(users));
    return answer;
  }
  const changeMVP = (value) => {
    setList(() => value);
    console.log(list);
  };

  return (
    <div>
      <SubHeader></SubHeader>
      <div className={s.sorting}>
        {/**<Selector className={s.sortingCategory}></Selector>
        <MultipleSlider name="колво коммитов" /> */}
      </div>
      <div className={s.mvpList}>
        <div className={s.listCategory}>
          {fields.map((field, id) => {
            return (
              <div className={`${field}`} key={Math.random()}>
                <button
                  className={s.categoryName}
                  onClick={(e) =>
                    changeMVP(sortByParam(list, field, previousClick))
                  }
                >
                  {field}
                </button>

                {list.map((el) => {
                  return (
                    <div className={s.mvpListEl} key={Math.random()}>
                      <Link
                        to={`user/:${el["username"]}/:${el["displayName"]}/:${el["personalWebsite"]}/:${el["profilePicUrl"]}`}
                      >
                        <span>{el[field]}</span>
                      </Link>
                    </div>
                  );
                })}
              </div>
            );
          })}
        </div>
      </div>
    </div>
  );
}

export default MVP;
