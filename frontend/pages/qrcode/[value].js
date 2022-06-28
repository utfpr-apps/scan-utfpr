import { Flex } from "@chakra-ui/react";
import { useRouter } from "next/router";
import QRCode from "react-qr-code";

const QRCodeValue = () => {
  const router = useRouter();

  return (
    <Flex height="100vh" width="100%" justify="center" align="center">
      <QRCode value={router.query.value || ""} />
    </Flex>
  );
};

export default QRCodeValue;
