import React, { useState } from "react";
import { connect } from "react-redux";

import {
  CircularProgress,
  Grid,
  InputBase,
  Paper,
  IconButton,
  Typography,
} from "@material-ui/core";
import SearchIcon from "@material-ui/icons/Search";

import { makeStyles } from "@material-ui/core/styles";

import strings from "../../localization/strings";

import { getPreproduct } from "../../redux/actions/preProductActionCreator";
import preProductReducer from "../../redux/reducers/preProductReducer";

import PreProductCard from "./preProductCard";

const useStyles = makeStyles({
  root: {
    padding: "3em",
  },
  inputContainer: {
    padding: "2px 4px",
    minWidth: 400,
    display: "flex",
  },
  input: {
    flex: 1,
  },
  iconButton: {
    padding: 10,
  },
});

const ProductCreateForm = (props) => {
  const classes = useStyles();

  const [link, setLink] = useState("");

  const emptyPreProduct = () => {
    return {
      name: "Name will be here",
      price: "0,0000",
      productPage: "https://google.com",
      imageUrl:
        "https://cdn.pixabay.com/photo/2017/02/16/13/42/box-2071537_960_720.png",
    };
  };

  const getPreProduct = () => {
    let preProduct = props.preProductReducer.preProduct;
    if(preProduct) {
      return preProduct;
    }

    return emptyPreProduct();
  }

  const handleClick = () => {
    props.getPreproduct(link);
  };

  return (
    <Paper className={classes.root} elevation={3}>
      <Typography variant="h6">
        {strings.CREATE_FORM.PRODUCT_CREATE.TITLE}
      </Typography>
      <PreProductCard inProgress={props.preProductReducer.gettingDataInProgress} preproduct={getPreProduct()} />
      <Paper className={classes.inputContainer} elevation={10}>
        <InputBase
          className={classes.input}
          placeholder={
            strings.CREATE_FORM.PRODUCT_CREATE.LINK_INPUT_PLACEHOLDER
          }
          value={link}
          onChange={(e) => setLink(e.target.value)}
        />
        <IconButton
          className={classes.iconButton}
          aria-label="search"
          onClick={handleClick}
          disabled={props.preProductReducer.gettingDataInProgress}
        >
          <SearchIcon />
        </IconButton>
      </Paper>
    </Paper>
  );
};

function mapDispatchToProps(dispatch) {
  return {
    getPreproduct: (link) => getPreproduct(link, dispatch),
  };
}

const mapStateToProps = (state) => {
  return { preProductReducer: state.preProductReducer };
};
export default connect(mapStateToProps, mapDispatchToProps)(ProductCreateForm);
