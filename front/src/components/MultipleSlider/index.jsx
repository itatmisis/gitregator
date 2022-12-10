import { Slider } from "antd";

import { React, useState } from "react";
//import { useDispatch } from "react-redux";
const marks = {
  0: "0",
  1000: "1000",
};

const MultipleSlider = (props) => {
  //const dispatch = useDispatch();
  const [value, setValue] = useState(0);
  return (
    <div
      style={{
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
      }}
    >
      <span>{props.name}</span>
      <Slider
        range={{ draggableTrack: true }}
        marks={marks}
        defaultValue={value}
        onAfterChange={(e) => setValue(e)}
        style={{ width: "200px", zIndex: "4" }}
        max={1000}
      />
    </div>
  );
};

export default MultipleSlider;
