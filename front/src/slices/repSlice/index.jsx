import { createSlice } from "@reduxjs/toolkit";

export const repSlice = createSlice({
  name: "rep",
  initialState: {
    rep: [
      {
        repositoryHttpUrl: "name",
        repositoryOwner: "repOwner",
        repositoryName: "repName",
        repositoryDescription: "repositoryDescription",
        openCommitsTotal: 0,
        openIssuesTotal: 0,
        pullRequestsTotal: 0,
        mostUsedLanguage: "string",
        languages: {
          additionalProp1: 0,
          additionalProp2: 0,
          additionalProp3: 0,
        },
        collaborators: [
          {
            id: 0,
            username: "string",
            description: "string",
            profilePicUrl: "string",
            displayName: "string",
            personalWebsite: "string",
            followersCount: 0,
            followingCount: 0,
            location: "string",
            company: "string",
            email: "string",
            commitsTotal: 0,
            pullRequestsTotal: 0,
            activityIndex: 0,
            issuesTotal: 0,
          },
        ],
        issuers: [
          {
            id: 0,
            username: "string",
            description: "string",
            profilePicUrl: "string",
            displayName: "string",
            personalWebsite: "string",
            followersCount: 0,
            followingCount: 0,
            location: "string",
            company: "string",
            email: "string",
            commitsTotal: 0,
            pullRequestsTotal: 0,
            activityIndex: 0,
            issuesTotal: 0,
          },
        ],
      },
    ],
  },
  reducers: {
    setRep(state, action) {
      state.rep = action.payload;
    },
  },
});

// Action creators are generated for each case reducer function
export const { setRep } = repSlice.actions;

export default repSlice.reducer;
