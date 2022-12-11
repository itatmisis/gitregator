import { configureStore } from "@reduxjs/toolkit";
import { givenLinkReducer, mvpListReducer } from "../slices";
export const store = configureStore({
  reducer: {
    mvpList: mvpListReducer,
    givenLink: givenLinkReducer,
  },
});