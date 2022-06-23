import Image from "next/image";

import { useSession, signOut } from "next-auth/react";

import {
  Avatar,
  Box,
  Flex,
  Text,
  Menu,
  MenuButton,
  MenuList,
  MenuItem,
  IconButton,
} from "@chakra-ui/react";

import { IoExitOutline, IoMenu } from "react-icons/io5";

import logoUTFPR from "../../public/assets/logo-utfpr.png";

const NavbarUserInformation = ({ user }) => (
  <Flex align="center">
    <Text mr="14px" color="blackText" display={["none", "block"]}>
      {user?.name}
    </Text>

    <Box
      border="2px solid #DFE0EB"
      borderRadius="50%"
      p="2px"
      boxShadow="rgba(100, 100, 111, 0.2) 0px 7px 29px 0px"
    >
      <Avatar name={user?.name} src={user.image} />
    </Box>
  </Flex>
);

const Navbar = ({ showSidebarButton = true, toggleSidebar }) => {
  const { data, status } = useSession();

  console.log(data);

  return (
    <Flex
      position="sticky"
      px="50px"
      py="20px"
      justify="space-between"
      width="100%"
      height="93px"
    >
      {showSidebarButton ? (
        <IconButton
          icon={<IoMenu size={40} />}
          colorScheme="blackAlpha"
          variant="ghost"
          onClick={toggleSidebar}
        />
      ) : (
        <Image src={logoUTFPR} alt="logo UTFPR" height="49px" width="128px" />
      )}

      {status === "authenticated" && (
        <Menu>
          <MenuButton aria-label="Options">
            <NavbarUserInformation user={data?.user} />
          </MenuButton>

          <MenuList>
            <MenuItem icon={<IoExitOutline size={20} />} onClick={signOut}>
              Encerrar sessão
            </MenuItem>
          </MenuList>
        </Menu>
      )}
    </Flex>
  );
};

export default Navbar;
