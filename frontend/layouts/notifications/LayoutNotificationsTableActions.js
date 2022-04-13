import {
  Menu,
  MenuButton,
  MenuList,
  MenuItem,
  MenuDivider,
  IconButton,
} from "@chakra-ui/react";

import { BiDotsVerticalRounded } from "react-icons/bi";

import LayoutNotificationsTableActionsStudents from "./LayoutNotificationsTableActionsStudents";

const LayoutNotificationsTableActions = ({ notification }) => (
  <Menu>
    <MenuButton
      as={IconButton}
      aria-label="Options"
      icon={<BiDotsVerticalRounded />}
      variant="ghost"
    />

    <MenuList>
      <LayoutNotificationsTableActionsStudents notification={notification} />
      <MenuDivider />
      <MenuItem>Alterar status</MenuItem>
      <MenuItem>Remover notificação</MenuItem>
    </MenuList>
  </Menu>
);

export default LayoutNotificationsTableActions;
