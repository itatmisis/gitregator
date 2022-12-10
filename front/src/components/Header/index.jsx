import { Link } from "react-router-dom";

import s from "./Header.module.css";
function Header() {
  return (
    <header className={s.header}>
      <Link to="/">
        <span>Главная</span>
      </Link>
      <Link to="/about">
        <span>Услуги</span>
      </Link>
      <Link to="/">
        <span>Наши контакты</span>
      </Link>
    </header>
  );
}

export default Header;
