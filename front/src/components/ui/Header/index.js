import s from "./Header.module.css";
function Header() {
  return (
    <header className={s.header}>
      <ul>
        <li className={s.subpg}>Главная</li>
        <li className={s.subpg}>О нас</li>
        <li className={s.subpg}>1</li>
        <li className={s.subpg}>2</li>
        <li className={s.subpg}>3</li>
      </ul>
    </header>
  );
}

export default Header;
