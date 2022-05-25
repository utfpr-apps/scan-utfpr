import Head from "next/head";

import LayoutUsers from "layouts/users/LayoutUsers";

const Users = () => {
  return (
    <>
      <Head>
        <title>Usuários - SCAN UTFPR</title>
      </Head>

      <LayoutUsers />
    </>
  );
};

export default Users;
