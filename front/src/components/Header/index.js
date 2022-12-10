import { Link } from "react-router-dom";

import s from "./Header.module.css";
function Header() {
  return (
    <header className={s.header}>
      <Link to="/1">
        <span>Главная</span>
      </Link>
      <Link to="/about">
        <span>О нас</span>
      </Link>
      <Link to="/">
        <span>Партнеры</span>
      </Link>
    </header>
  );
}

export default Header;
