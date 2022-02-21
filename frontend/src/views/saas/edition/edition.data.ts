import { Status } from '/@/utils/status';
import { BasicColumn } from '/@/components/Table';
import { FormSchema } from '/@/components/Table';
import { DescItem } from '../../../components/Description/src/typing';
import { commonTagRender } from '/@/utils/tagUtil';
import { formatToDate } from '/@/utils/dateUtil';
import { getEditionList } from '/@/api/edition';
import { omit } from 'lodash-es';
import { OptionsItem } from '/@/utils/model';

export const columns: BasicColumn[] = [
  {
    title: '名称',
    dataIndex: 'name',
    width: 120,
  },
  {
    title: '价格',
    dataIndex: 'price',
    width: 120,
    format: (value) => `¥ ${value}`.replace(/\\B(?=(\\d{3})+(?!\\d))/g, ','),
  },
  {
    title: '排序',
    dataIndex: 'sort',
    width: 50,
  },
  {
    title: '备注',
    dataIndex: 'remark',
    width: 120,
    align: 'left',
  },
];

export const searchFormSchema: FormSchema[] = [
  {
    field: 'name',
    label: '名称',
    component: 'Input',
    colProps: { span: 6 },
  },
];

export const editionSchemas = [
  {
    field: 'divider-editioninfo',
    component: 'Divider',
    label: '版本信息',
  },
  {
    field: 'name',
    component: 'Input',
    label: '名称',
    rules: [
      {
        required: true,
        message: '版本名称不允许为空',
      },
      {
        max: 50,
        message: '版本长度不允许超过50个字符',
        validateTrigger: ['change', 'blur'],
      },
    ],
  },
  {
    field: 'price',
    component: 'InputNumber',
    label: '价格',
    componentProps: {
      style: 'width: 100%;',
      step: '0.01',
      formatter: (value) => `¥ ${value}`.replace(/\\B(?=(\\d{3})+(?!\\d))/g, ','),
      parser: (value) => value.replace(/\\$\\s?|(,*)/g, ''),
    },
  },
  {
    field: 'sort',
    component: 'InputNumber',
    label: '排序',
    componentProps: {
      style: 'width: 100%;',
    },
  },
  {
    field: 'remark',
    component: 'InputTextArea',
    label: '备注',
  },
];

export const editionDetailSchemas: DescItem[] = [
  {
    field: 'name',
    label: '名称',
  },
  {
    field: 'sort',
    label: '排序',
  },
  {
    label: '状态',
    field: 'status',
    render: (value) => {
      if (value === Status.Valid) {
        return commonTagRender('blue', '启用');
      } else {
        return commonTagRender('red', '停用');
      }
    },
  },
  {
    field: 'remark',
    label: '备注',
    span: 2,
  },
  {
    label: '创建时间',
    field: 'createdTime',
    render: (value) => {
      if (value) {
        return formatToDate(value, 'YYYY-MM-DD HH:MM:ss');
      }
      return null;
    },
  },
  {
    label: '最后更新时间',
    field: 'updatedTime',
    render: (value) => {
      if (value) {
        return formatToDate(value, 'YYYY-MM-DD HH:MM:ss');
      }
      return null;
    },
  },
];

export const getEditionOptions = async () => {
  const editionList = await getEditionList();
  const editionOptions = editionList.reduce((prev, next: Recordable) => {
    if (next) {
      prev.push({
        ...omit(next, ['name', 'id']),
        label: next['name'],
        value: next['id'],
      });
    }
    return prev;
  }, [] as OptionsItem[]);
  return editionOptions;
};