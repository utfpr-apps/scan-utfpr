import Head from "next/head";

import LayoutNotifications from "layouts/notifications/LayoutNotifications";

const Notifications = () => {
  return (
    <>
      <Head>
        <title>Notificações - SCAN UTFPR</title>
      </Head>

      <LayoutNotifications />
    </>
  );
};

export default Notifications;
