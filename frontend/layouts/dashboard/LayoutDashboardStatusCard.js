import { Text } from "@chakra-ui/react";

import Container from "components/Container";

const LayoutDashboardStatusCard = ({ status, index }) => {
  return (
    <Container
      key={index}
      py="18px"
      px="25px"
      align="center"
      minW="310px"
      my="5px"
    >
      <Text
        color="greyText"
        fontSize="19px"
        fontWeight={700}
        letterSpacing="0.4px"
      >
        {status.title}
      </Text>

      <Text mt="12px" color="blackText" fontSize="40px" fontWeight={700}>
        {status.quantity}
      </Text>
    </Container>
  );
};

export default LayoutDashboardStatusCard;
