import Head from "next/head";

import LayoutDashboard from "../layouts/dashboard/LayoutDashboard";

export default function Home() {
  return (
    <>
      <Head>
        <title>Dashboard - SCAN UTFPR</title>
      </Head>

      <LayoutDashboard />
    </>
  );
}
