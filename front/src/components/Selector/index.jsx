import Select from "react-select";
// eslint-disable-next-line no-unused-vars
import { useDispatch, useSelector } from "react-redux";
import { useState } from "react";

const selectorOptions = [
  { value: 1, label: "точки на карте" },
  { value: 2, label: "тепловая карта" },
  { value: 3, label: "сектор" },
  { value: 4, label: "ваша точка" },
];

function Selector() {
  const [choise, setChoise] = useState(1);
  /*const dispatch = useDispatch();
  const selector = useSelector((state) => state.selector.selector);
  */
  return (
    <Select
      defaultValue={{ value: choise, label: "район" }}
      style={{ width: "330px", zIndex: "4" }}
      onChange={(e) => setChoise(e.value)}
      options={selectorOptions}
    />
  );
}
/**
 * сделал стейт по автозаполнению селекта,но он не меняется
 */
export default Selector;
