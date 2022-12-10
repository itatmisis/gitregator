import { Routes, Route } from "react-router-dom";

import "./App.css";
import Layout from "./components/Layout";
import MainPg from "./components/MainPg";
import MVP from "./components/MVP";

function App() {
  return (
    <>
      <Layout>
        <Routes>
          <Route path="/" element={<MainPg></MainPg>}></Route>
          <Route path="/about" element={<MVP></MVP>}></Route>
          <Route path="/callUs" element={<></>}></Route>
        </Routes>
      </Layout>
    </>
  );
}

export default App;
