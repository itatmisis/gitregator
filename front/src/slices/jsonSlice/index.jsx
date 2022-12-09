import { createSlice } from "@reduxjs/toolkit";

export const jsonSlice = createSlice({
  name: "json",
  initialState: { value: false },
  reducers: {
    setJson(state, action) {
      state.json = action.payload;
    },
  },
});

// Action creators are generated for each case reducer function
export const { setJson } = jsonSlice.actions;

export default jsonSlice.reducer;
