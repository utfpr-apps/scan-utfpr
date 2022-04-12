import Head from "next/head";

import LayoutUsers from "layouts/users/LayoutUsers";

const Users = () => {
  return (
    <>
      <Head>
        <title>Notificações - SCAN UTFPR</title>
      </Head>

      <LayoutUsers />
    </>
  );
};

export default Users;
