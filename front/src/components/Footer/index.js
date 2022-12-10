import { Link } from "react-router-dom";

import s from "./Footer.module.css";
function Footer() {
  return (
    <footer className={s.footer}>
      <Link to="/help">
        <div className={s.helpBox}>
          <span>Техническая поддержка</span>
          <span className={s.mail}>support@devrelserv.ru</span>
        </div>
      </Link>
      <Link to="/about">
        <span>© Debrelserv, 2022</span>
      </Link>
    </footer>
  );
}

export default Footer;
