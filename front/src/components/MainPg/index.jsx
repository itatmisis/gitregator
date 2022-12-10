import { useEffect, useState, useRef } from "react";
import { CSSTransition } from "react-transition-group";
import EnterField from "../EnterField";
import "./MainPg.css";
function MainPg(props) {
  const [mount, setMount] = useState(true);
  const nodeRef = useRef(null);
  useEffect(() => {
    setTimeout(() => {
      setMount(!mount);
    }, 2000);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
  return (
    <>
      <CSSTransition
        in={mount}
        timeout={2000}
        classNames="animatedLabel"
        nodeRef={nodeRef}
      >
        {(state) => (
          <div className={`label ${state}`} ref={nodeRef}>
            {mount && <h1>Project</h1>}
            {mount && (
              <span>Описание проекта для понимания цели нашей работы</span>
            )}
          </div>
        )}
      </CSSTransition>
      <CSSTransition in={mount} timeout={200} classNames="enter">
        <>{!mount && <EnterField></EnterField>}</>
      </CSSTransition>
    </>
  );
}

export default MainPg;
