import { Routes, Route } from "react-router-dom";

import "./App.css";
import Layout from "./components/Layout";
import MainPg from "./components/MainPg";
import MVP from "./components/MVP";
import UserPage from "./components/UserPage";
function App() {
  return (
    <>
      <Layout>
        <Routes>
          <Route path="/" element={<MainPg></MainPg>}></Route>
          <Route path="/about" element={<MVP></MVP>}></Route>
          <Route path="/callUs" element={<></>}></Route>
          <Route
            path="about/user/:username/:displayName"
            element={<UserPage />}
          ></Route>
          <Route
            path="/*"
            element={<>Sorry, we can't find the page you're looking for</>}
          ></Route>
        </Routes>
      </Layout>
    </>
  );
}

export default App;
