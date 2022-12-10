import { useState } from "react";
import s from "./EnterField.module.css";
function EnterField() {
  const [inp, setInp] = useState("URL ссылка");

  function handleSubmit(e) {
    e.preventDefault();
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
      </form>
    </div>
  );
}

export default EnterField;
