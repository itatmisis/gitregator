import { useState } from "react";
import MultipleSlider from "../MultipleSlider";
import Selector from "../Selector";
import s from "./MVP.module.css";

function MVP() {
  const [mvpList, setMvpList] = useState([
    {
      username: "Wokkta",
      commitsTotal: 93,
      issuesTotal: 153,
      pullRequestTotal: 122,
      mostUsedLanguage: "js",
    },
    {
      username: "Tolik",
      commitsTotal: 19,
      issuesTotal: 161,
      pullRequestTotal: 143,
      mostUsedLanguage: "python",
    },
    {
      username: "Wort",
      commitsTotal: 1113,
      issuesTotal: 13,
      pullRequestTotal: 12,
      mostUsedLanguage: "java",
    },
    {
      username: "Wokkta",
      commitsTotal: 93,
      issuesTotal: 153,
      pullRequestTotal: 122,
      mostUsedLanguage: "js",
    },
    {
      username: "Tolik",
      commitsTotal: 19,
      issuesTotal: 161,
      pullRequestTotal: 143,
      mostUsedLanguage: "python",
    },
    {
      username: "Wort",
      commitsTotal: 1113,
      issuesTotal: 13,
      pullRequestTotal: 12,
      mostUsedLanguage: "java",
    },
    {
      username: "Wokkta",
      commitsTotal: 93,
      issuesTotal: 153,
      pullRequestTotal: 122,
      mostUsedLanguage: "js",
    },
    {
      username: "Tolik",
      commitsTotal: 19,
      issuesTotal: 161,
      pullRequestTotal: 143,
      mostUsedLanguage: "python",
    },
    {
      username: "Wort",
      commitsTotal: 1113,
      issuesTotal: 13,
      pullRequestTotal: 12,
      mostUsedLanguage: "java",
    },
    {
      username: "Wokkta",
      commitsTotal: 93,
      issuesTotal: 153,
      pullRequestTotal: 122,
      mostUsedLanguage: "js",
    },
    {
      username: "Tolik",
      commitsTotal: 19,
      issuesTotal: 161,
      pullRequestTotal: 143,
      mostUsedLanguage: "python",
    },
    {
      username: "Wort",
      commitsTotal: 1113,
      issuesTotal: 13,
      pullRequestTotal: 12,
      mostUsedLanguage: "java",
    },
    {
      username: "Wokkta",
      commitsTotal: 93,
      issuesTotal: 153,
      pullRequestTotal: 122,
      mostUsedLanguage: "js",
    },
    {
      username: "Tolik",
      commitsTotal: 19,
      issuesTotal: 161,
      pullRequestTotal: 143,
      mostUsedLanguage: "python",
    },
    {
      username: "Wort",
      commitsTotal: 1113,
      issuesTotal: 13,
      pullRequestTotal: 12,
      mostUsedLanguage: "java",
    },
    {
      username: "Wokkta",
      commitsTotal: 93,
      issuesTotal: 153,
      pullRequestTotal: 122,
      mostUsedLanguage: "js",
    },
    {
      username: "Tolik",
      commitsTotal: 19,
      issuesTotal: 161,
      pullRequestTotal: 143,
      mostUsedLanguage: "python",
    },
    {
      username: "Wort",
      commitsTotal: 1113,
      issuesTotal: 13,
      pullRequestTotal: 12,
      mostUsedLanguage: "java",
    },
    {
      username: "Wokkta",
      commitsTotal: 93,
      issuesTotal: 153,
      pullRequestTotal: 122,
      mostUsedLanguage: "js",
    },
    {
      username: "Tolik",
      commitsTotal: 19,
      issuesTotal: 161,
      pullRequestTotal: 143,
      mostUsedLanguage: "python",
    },
    {
      username: "Wort",
      commitsTotal: 1113,
      issuesTotal: 13,
      pullRequestTotal: 12,
      mostUsedLanguage: "java",
    },
    {
      username: "Wokkta",
      commitsTotal: 93,
      issuesTotal: 153,
      pullRequestTotal: 122,
      mostUsedLanguage: "js",
    },
    {
      username: "Tolik",
      commitsTotal: 19,
      issuesTotal: 161,
      pullRequestTotal: 143,
      mostUsedLanguage: "python",
    },
    {
      username: "Wort",
      commitsTotal: 1113,
      issuesTotal: 13,
      pullRequestTotal: 12,
      mostUsedLanguage: "java",
    },
    {
      username: "Wokkta",
      commitsTotal: 93,
      issuesTotal: 153,
      pullRequestTotal: 122,
      mostUsedLanguage: "js",
    },
    {
      username: "Tolik",
      commitsTotal: 19,
      issuesTotal: 161,
      pullRequestTotal: 143,
      mostUsedLanguage: "python",
    },
    {
      username: "Wort",
      commitsTotal: 1113,
      issuesTotal: 13,
      pullRequestTotal: 12,
      mostUsedLanguage: "java",
    },
    {
      username: "Wokkta",
      commitsTotal: 93,
      issuesTotal: 153,
      pullRequestTotal: 122,
      mostUsedLanguage: "js",
    },
    {
      username: "Tolik",
      commitsTotal: 19,
      issuesTotal: 161,
      pullRequestTotal: 143,
      mostUsedLanguage: "python",
    },
    {
      username: "Wort",
      commitsTotal: 1113,
      issuesTotal: 13,
      pullRequestTotal: 12,
      mostUsedLanguage: "java",
    },
    {
      username: "Wokkta",
      commitsTotal: 93,
      issuesTotal: 153,
      pullRequestTotal: 122,
      mostUsedLanguage: "js",
    },
    {
      username: "Tolik",
      commitsTotal: 19,
      issuesTotal: 161,
      pullRequestTotal: 143,
      mostUsedLanguage: "python",
    },
    {
      username: "Wort",
      commitsTotal: 1113,
      issuesTotal: 13,
      pullRequestTotal: 12,
      mostUsedLanguage: "java",
    },
    {
      username: "Wokkta",
      commitsTotal: 93,
      issuesTotal: 153,
      pullRequestTotal: 122,
      mostUsedLanguage: "js",
    },
    {
      username: "Tolik",
      commitsTotal: 19,
      issuesTotal: 161,
      pullRequestTotal: 143,
      mostUsedLanguage: "python",
    },
    {
      username: "Wort",
      commitsTotal: 1113,
      issuesTotal: 13,
      pullRequestTotal: 12,
      mostUsedLanguage: "java",
    },
    {
      username: "Wokkta",
      commitsTotal: 93,
      issuesTotal: 153,
      pullRequestTotal: 122,
      mostUsedLanguage: "js",
    },
    {
      username: "Tolik",
      commitsTotal: 19,
      issuesTotal: 161,
      pullRequestTotal: 143,
      mostUsedLanguage: "python",
    },
    {
      username: "Wort",
      commitsTotal: 1113,
      issuesTotal: 13,
      pullRequestTotal: 12,
      mostUsedLanguage: "java",
    },
    {
      username: "Wokkta",
      commitsTotal: 93,
      issuesTotal: 153,
      pullRequestTotal: 122,
      mostUsedLanguage: "js",
    },
    {
      username: "Tolik",
      commitsTotal: 19,
      issuesTotal: 161,
      pullRequestTotal: 143,
      mostUsedLanguage: "python",
    },
    {
      username: "Wort",
      commitsTotal: 1113,
      issuesTotal: 13,
      pullRequestTotal: 12,
      mostUsedLanguage: "java",
    },
    {
      username: "Wokkta",
      commitsTotal: 93,
      issuesTotal: 153,
      pullRequestTotal: 122,
      mostUsedLanguage: "js",
    },
    {
      username: "Tolik",
      commitsTotal: 19,
      issuesTotal: 161,
      pullRequestTotal: 143,
      mostUsedLanguage: "python",
    },
    {
      username: "Wort",
      commitsTotal: 1113,
      issuesTotal: 13,
      pullRequestTotal: 12,
      mostUsedLanguage: "java",
    },
    {
      username: "Wokkta",
      commitsTotal: 93,
      issuesTotal: 153,
      pullRequestTotal: 122,
      mostUsedLanguage: "js",
    },
    {
      username: "Tolik",
      commitsTotal: 19,
      issuesTotal: 161,
      pullRequestTotal: 143,
      mostUsedLanguage: "python",
    },
    {
      username: "Wort",
      commitsTotal: 1113,
      issuesTotal: 13,
      pullRequestTotal: 12,
      mostUsedLanguage: "java",
    },
    {
      username: "Wokkta",
      commitsTotal: 93,
      issuesTotal: 153,
      pullRequestTotal: 122,
      mostUsedLanguage: "js",
    },
    {
      username: "Tolik",
      commitsTotal: 19,
      issuesTotal: 161,
      pullRequestTotal: 143,
      mostUsedLanguage: "python",
    },
    {
      username: "Wort",
      commitsTotal: 1113,
      issuesTotal: 13,
      pullRequestTotal: 12,
      mostUsedLanguage: "java",
    },
    {
      username: "Wokkta",
      commitsTotal: 93,
      issuesTotal: 153,
      pullRequestTotal: 122,
      mostUsedLanguage: "js",
    },
    {
      username: "Tolik",
      commitsTotal: 19,
      issuesTotal: 161,
      pullRequestTotal: 143,
      mostUsedLanguage: "python",
    },
    {
      username: "Wort",
      commitsTotal: 1113,
      issuesTotal: 13,
      pullRequestTotal: 12,
      mostUsedLanguage: "java",
    },
    {
      username: "Wokkta",
      commitsTotal: 93,
      issuesTotal: 153,
      pullRequestTotal: 122,
      mostUsedLanguage: "js",
    },
    {
      username: "Tolik",
      commitsTotal: 19,
      issuesTotal: 161,
      pullRequestTotal: 143,
      mostUsedLanguage: "python",
    },
    {
      username: "Wort",
      commitsTotal: 1113,
      issuesTotal: 13,
      pullRequestTotal: 12,
      mostUsedLanguage: "java",
    },
    {
      username: "Wokkta",
      commitsTotal: 93,
      issuesTotal: 153,
      pullRequestTotal: 122,
      mostUsedLanguage: "js",
    },
    {
      username: "Tolik",
      commitsTotal: 19,
      issuesTotal: 161,
      pullRequestTotal: 143,
      mostUsedLanguage: "python",
    },
    {
      username: "Wort",
      commitsTotal: 1113,
      issuesTotal: 13,
      pullRequestTotal: 12,
      mostUsedLanguage: "java",
    },
    {
      username: "Wokkta",
      commitsTotal: 93,
      issuesTotal: 153,
      pullRequestTotal: 122,
      mostUsedLanguage: "js",
    },
    {
      username: "Tolik",
      commitsTotal: 19,
      issuesTotal: 161,
      pullRequestTotal: 143,
      mostUsedLanguage: "python",
    },
    {
      username: "Wort",
      commitsTotal: 1113,
      issuesTotal: 13,
      pullRequestTotal: 12,
      mostUsedLanguage: "java",
    },
    {
      username: "Wokkta",
      commitsTotal: 93,
      issuesTotal: 153,
      pullRequestTotal: 122,
      mostUsedLanguage: "js",
    },
    {
      username: "Tolik",
      commitsTotal: 19,
      issuesTotal: 161,
      pullRequestTotal: 143,
      mostUsedLanguage: "python",
    },
    {
      username: "Wort",
      commitsTotal: 1113,
      issuesTotal: 13,
      pullRequestTotal: 12,
      mostUsedLanguage: "java",
    },
    {
      username: "Wokkta",
      commitsTotal: 93,
      issuesTotal: 153,
      pullRequestTotal: 122,
      mostUsedLanguage: "js",
    },
    {
      username: "Tolik",
      commitsTotal: 19,
      issuesTotal: 161,
      pullRequestTotal: 143,
      mostUsedLanguage: "python",
    },
    {
      username: "Wort",
      commitsTotal: 1113,
      issuesTotal: 13,
      pullRequestTotal: 12,
      mostUsedLanguage: "java",
    },
    {
      username: "Wokkta",
      commitsTotal: 93,
      issuesTotal: 153,
      pullRequestTotal: 122,
      mostUsedLanguage: "js",
    },
    {
      username: "Tolik",
      commitsTotal: 19,
      issuesTotal: 161,
      pullRequestTotal: 143,
      mostUsedLanguage: "python",
    },
    {
      username: "Wort",
      commitsTotal: 1113,
      issuesTotal: 13,
      pullRequestTotal: 12,
      mostUsedLanguage: "java",
    },
  ]);

  const fields = [
    "username",
    "commitsTotal",
    "issuesTotal",
    "pullRequestTotal",
    "mostUsedLanguage",
  ];
  const [previousClick, setPreviousClick] = useState("");
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
          setPreviousClick("");
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
    setMvpList(() => value);
    console.log(mvpList);
  };
  /*
  console.log("start");
  mvpList.forEach((e) => {
    console.log(`${e.username} ${e.commitsTotal} ${e.issuesTotal}`);
  });
  console.log();
  console.log("changed");
  sortByParam(mvpList, fields[1]);
  console.log("start1");
  mvpList.forEach((e) => {
    console.log(`${e.username} ${e.commitsTotal} ${e.issuesTotal}`);
  });
  console.log("changed1");
  sortByParam(mvpList, fields[0]); */

  return (
    <div>
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
                    changeMVP(sortByParam(mvpList, field, previousClick))
                  }
                >
                  {field}
                </button>
                {mvpList.map((el) => {
                  return (
                    <div className={s.mvpListEl} key={Math.random()}>
                      <span>{el[field]}</span>
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
