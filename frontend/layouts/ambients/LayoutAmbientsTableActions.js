import {
  Menu,
  MenuButton,
  MenuList,
  MenuItem,
  IconButton,
} from "@chakra-ui/react";

import { BiDotsVerticalRounded } from "react-icons/bi";
import LayoutAmbientsTableActionsEditAmbient from "./LayoutAmbientsTableActionsEditAmbient";
import LayoutAmbientsTableActionsRemoveAmbient from "./LayoutAmbientsTableActionsRemoveAmbient";

const LayoutAmbientsTableActions = ({ ambient }) => (
  <Menu>
    <MenuButton
      as={IconButton}
      aria-label="Options"
      icon={<BiDotsVerticalRounded />}
      variant="ghost"
    />

    <MenuList>
      <LayoutAmbientsTableActionsEditAmbient ambient={ambient} />
      <LayoutAmbientsTableActionsRemoveAmbient ambient={ambient} />
    </MenuList>
  </Menu>
);

export default LayoutAmbientsTableActions;
