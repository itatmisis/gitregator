import { createSlice } from "@reduxjs/toolkit";

export const givenLinkSlice = createSlice({
  name: "givenLink",
  initialState: {
    givenLink: "URL ссылка",
  },
  reducers: {
    setGivenLink(state, action) {
      state.givenLink = action.payload;
    },
  },
});

// Action creators are generated for each case reducer function
export const { setGivenLink } = givenLinkSlice.actions;

export default givenLinkSlice.reducer;
