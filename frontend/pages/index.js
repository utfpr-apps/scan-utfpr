import Head from "next/head";
import LayoutDashboard from "../layouts/dashboard/LayoutDashboard";

export default function Home() {
  return (
    <>
      <Head>
        <link rel="preconnect" href="https://fonts.googleapis.com" />
        <link
          rel="preconnect"
          href="https://fonts.gstatic.com"
          crossOrigin="true"
        />
        <link
          href="https://fonts.googleapis.com/css2?family=Mulish:wght@300;400;600;700&display=swap"
          rel="stylesheet"
        />
        <title>SCAN UTFPR - Pato Branco</title>
      </Head>

      <LayoutDashboard />
    </>
  );
}
