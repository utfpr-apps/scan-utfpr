import Head from "next/head";

import LayoutRooms from "layouts/rooms/LayoutRooms";

const Salas = () => {
  return (
    <>
      <Head>
        <title>Salas e Ambientes - SCAN UTFPR</title>
      </Head>

      <LayoutRooms />
    </>
  );
};

export default Salas;
