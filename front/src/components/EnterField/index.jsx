import { useState } from "react";
import { Link } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";

import { setGivenLink } from "../../slices/givenLinkSlice";

import s from "./EnterField.module.css";

function EnterField() {
  const givenLink = useSelector((state) => state.givenLink.givenLink);
  const dispatch = useDispatch();
  const [inp, setInp] = useState(JSON.parse(JSON.stringify(givenLink)));
  const [flag, setFlag] = useState(0);

  function handleSubmit(e) {
    dispatch(setGivenLink(inp));
    setFlag(() => !flag);
    setTimeout(() => {
      setFlag(!flag);
    }, 4000);
    console.log(givenLink);
    //setInp("URL ссылка");
  }

  return (
    <div className={s.EnterField}>
      <div className={s.textField}>
        <h1>Поле для ввода</h1>
        <span>Описание поле для ввода для юзера</span>
      </div>
      <form className={s.linkForm} onSubmit={handleSubmit}>
        <input
          type="text"
          className={s.input}
          placeholder={givenLink}
          onChange={(e) => setInp(e.target.value)}
        ></input>

        <Link to="/about">
          <button className={s.enterBtn} onClick={handleSubmit}>
            <div className={s.insideBtn}></div>
          </button>
        </Link>
      </form>
    </div>
  );
}

export default EnterField;
