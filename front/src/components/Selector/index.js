import Select from "react-select";
import { useDispatch, useSelector } from "react-redux";
import { setSelector } from "../../../slices/selectModelSlice";

const selectorOptions = [
  { value: 1, label: "точки на карте" },
  { value: 2, label: "тепловая карта" },
  { value: 3, label: "сектор" },
  { value: 4, label: "ваша точка" },
];

function Selector() {
  const dispatch = useDispatch();
  const selector = useSelector((state) => state.selector.selector);

  return (
    <Select
      defaultValue={{ value: selector, label: "район" }}
      style={{ width: "330px", zIndex: "4" }}
      onChange={(e) => dispatch(setSelector(e.value))}
      options={selectorOptions}
    />
  );
}
/**
 * сделал стейт по автозаполнению селекта,но он не меняется
 */
export default Selector;
