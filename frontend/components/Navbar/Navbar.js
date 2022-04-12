import Image from "next/image";

import { Avatar, Box, Flex, Text } from "@chakra-ui/react";

import logoUTFPR from "../../public/assets/logo-utfpr.png";

const Navbar = () => (
  <Flex
    position="sticky"
    px="50px"
    py="20px"
    justify="space-between"
    width="100%"
    height="93px"
  >
    <Image src={logoUTFPR} alt="logo UTFPR" height="49px" width="128px" />

    <Flex align="center">
      <Text mr="14px" color="blackText" display={["none", "block"]}>
        Pontarolo
      </Text>

      <Box
        border="2px solid #DFE0EB"
        borderRadius="50%"
        p="2px"
        boxShadow="rgba(100, 100, 111, 0.2) 0px 7px 29px 0px"
      >
        <Avatar name="Dan Abrahmov" src="https://bit.ly/dan-abramov" />
      </Box>
    </Flex>
  </Flex>
);

export default Navbar;
