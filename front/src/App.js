import { Routes, Route, Link, json } from "react-router-dom";

import "./App.css";
import Layout from "./components/Layout";

function App() {
  return (
    <>
      <Layout>
        <Routes>
          <Route path="/1" element={<Layout></Layout>}></Route>
          <Route path="/about" element={<></>}></Route>
          <Route path="/callUs" element={<></>}></Route>
        </Routes>
      </Layout>
    </>
  );
}

export default App;
