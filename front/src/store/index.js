import { configureStore } from "@reduxjs/toolkit";
import { mvpListReducer } from "../slices";
export const store = configureStore({
  reducer: {
    mvpList: mvpListReducer,
  },
});
