import { useState } from "react";
import { Link } from "react-router-dom";
import s from "./EnterField.module.css";
function EnterField() {
  const [inp, setInp] = useState("URL ссылка");

  function handleSubmit(e) {
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
          placeholder={inp}
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
