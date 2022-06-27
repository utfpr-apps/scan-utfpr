import { useRouter } from "next/router";
import Link from "next/link";
import Image from "next/image";

import {
  Box,
  Flex,
  Text,
  Drawer,
  DrawerOverlay,
  DrawerCloseButton,
  DrawerHeader,
  DrawerBody,
  DrawerContent,
} from "@chakra-ui/react";

import {
  MdDashboard,
  MdMeetingRoom,
  MdNotificationImportant,
  MdPerson,
} from "react-icons/md";

import logoUTFPR from "public/assets/logo-utfpr.png";

const links = [
  {
    id: 1,
    title: "Dashboard",
    link: "/",
    icon: <MdDashboard />,
  },
  {
    id: 2,
    title: "Salas",
    link: "/salas",
    icon: <MdMeetingRoom />,
  },
  {
    id: 3,
    title: "Notificações",
    link: "/notificacoes",
    icon: <MdNotificationImportant />,
  },
  {
    id: 4,
    title: "Usuários",
    link: "/usuarios",
    icon: <MdPerson />,
  },
];

const SidebarContent = () => {
  const router = useRouter();

  return links.map((link) => (
    <Link key={link.id} href={link.link} passHref>
      <Flex
        py="18px"
        px="32px"
        align="center"
        cursor="pointer"
        color={router.route === link.link ? "#FECC00" : "#A4A6B3"}
        backgroundColor={router.route === link.link ? "#f0f1f6" : "transparent"}
        _hover={{
          cursor: "pointer",
          color: "#FECC00",
          backgroundColor: "#f0f1f6",
        }}
      >
        {link.icon}

        <Text ml="24px" fontSize="14px">
          {link.title}
        </Text>
      </Flex>
    </Link>
  ));
};

const Sidebar = ({ variant, isOpen, toggleSidebar }) => {
  if (variant === "sidebar") {
    return (
      <Box
        width="255px"
        height="calc(100vh - 93px)"
        direction="column"
        position="sticky"
      >
        <SidebarContent />
      </Box>
    );
  }

  return (
    <>
      <Drawer isOpen={isOpen} placement="left" onClose={toggleSidebar}>
        <DrawerOverlay>
          <DrawerContent background="lightBackground">
            <DrawerCloseButton />
            <DrawerHeader>
              <Flex align="flex-end">
                <Text fontWeight="bold" fontSize="1.5rem" mr="10px">
                  SCAN
                </Text>

                <Image
                  src={logoUTFPR}
                  alt="logo UTFPR"
                  height="49px"
                  width="128px"
                />
              </Flex>
            </DrawerHeader>
            <DrawerBody>
              <SidebarContent />
            </DrawerBody>
          </DrawerContent>
        </DrawerOverlay>
      </Drawer>
    </>
  );
};

export default Sidebar;
