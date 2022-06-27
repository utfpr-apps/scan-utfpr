import Head from "next/head";

import LayoutAmbients from "layouts/ambients/LayoutAmbients";

const Salas = () => {
  return (
    <>
      <Head>
        <title>Salas e Ambientes - SCAN UTFPR</title>
      </Head>

      <LayoutAmbients />
    </>
  );
};

export default Salas;
