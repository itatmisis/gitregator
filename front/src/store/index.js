import { configureStore } from "@reduxjs/toolkit";
import {
  givenLinkReducer,
  mvpListReducer,
  repReducer,
  userInfoReducer,
} from "../slices";
export const store = configureStore({
  reducer: {
    mvpList: mvpListReducer,
    givenLink: givenLinkReducer,
    rep: repReducer,
    userInfo: userInfoReducer,
  },
});
