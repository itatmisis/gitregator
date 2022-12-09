import { configureStore } from "@reduxjs/toolkit";
import { jsonReducer } from "../slices";

export const store = configureStore({
  reducer: {
    json: jsonReducer,
  },
});
