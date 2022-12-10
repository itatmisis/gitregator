import { Routes, Route, Link, json } from "react-router-dom";

import "./App.css";
import Layout from "./components/Layout";

function App() {
  return (
    <>
      <Routes>
        <Route path="/" element={<Layout></Layout>}></Route>
        <Route path="/" element={<></>}></Route>
        <Route path="/" element={<></>}></Route>
      </Routes>
    </>
  );
}

export default App;
