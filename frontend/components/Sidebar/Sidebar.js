import { useRouter } from "next/router";

import { Box, Flex, Text } from "@chakra-ui/react";

import {
  MdDashboard,
  MdMeetingRoom,
  MdNotificationImportant,
  MdPerson,
} from "react-icons/md";

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

const Sidebar = () => {
  const router = useRouter();

  return (
    <Box
      width="255px"
      height="calc(100vh - 93px)"
      direction="column"
      position="sticky"
    >
      {links.map((link) => (
        <Flex
          key={link.id}
          py="18px"
          px="32px"
          align="center"
          cursor="pointer"
          color={router.route === link.link ? "#FECC00" : "#A4A6B3"}
          backgroundColor={
            router.route === link.link ? "#f0f1f6" : "transparent"
          }
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
      ))}
    </Box>
  );
};

export default Sidebar;
